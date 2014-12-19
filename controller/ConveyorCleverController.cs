using System;
using System.Collections.Generic;
using System.Threading;

namespace ConveyorController
{
    abstract class ConveyorCleverController : ConveyorBasicController
    {
        public delegate void EmergencyStopDelegate(int emergencyStopId);
        public delegate void InputOutputDelegate(int bitId, bool on);
        public delegate void SenserDelegate(int senserId);
        public delegate void WorkingUnitDelegate(int unitTime);

        public readonly static EmergencyStopDelegate[] OnEmergencyStopTriggerOff = new EmergencyStopDelegate[EmergencyStopNum];
        public readonly static EmergencyStopDelegate[] OnEmergencyStopTriggerOn = new EmergencyStopDelegate[EmergencyStopNum];
        public readonly static InputOutputDelegate[] OnInputOff = new InputOutputDelegate[BitNum];
        public readonly static InputOutputDelegate[] OnInputOn = new InputOutputDelegate[BitNum];
        public readonly static InputOutputDelegate[] OnOutputOff = new InputOutputDelegate[BitNum];
        public readonly static InputOutputDelegate[] OnOutputOn = new InputOutputDelegate[BitNum];
        public readonly static SenserDelegate[] OnSenserTriggerOff = new SenserDelegate[SenserNum];
        public readonly static SenserDelegate[] OnSenserTriggerOn = new SenserDelegate[SenserNum];

        readonly static bool[] LastInput = new bool[BitNum];
        readonly static bool[] LastOutput = new bool[BitNum];
        readonly static List<DelayAction> WaitingAction = new List<DelayAction>();

        public static EmergencyStopDelegate onEmergencyStopTriggerOn;
        public static EmergencyStopDelegate onEmergencyStopTriggerOff;
        public static SenserDelegate onSenserTriggerOn;
        public static SenserDelegate onSenserTriggerOff;
        public static WorkingUnitDelegate onEveryWorkingUnit;

        public static void init()
        {
            Array.Copy(Input, LastInput, BitNum);
            Array.Copy(Output, LastOutput, BitNum);
            cleanDelegate();
            new Thread(callDelegateThreadMain).Start();
        }

        static void callDelegateThreadMain()
        {
            while (true)
            {
                for (int t = 0; t < EmergencyStopNum; t++)
                {
                    int bitIndex = (int)ConveyorInputDevice.EmergencyStop1 + t;
                    if (Input[bitIndex] != LastInput[bitIndex] && Input[bitIndex])
                    {
                        OnEmergencyStopTriggerOn[t](t);
                        onEmergencyStopTriggerOn(t);
                    }
                    else if (Input[bitIndex] != LastInput[bitIndex] && !Input[bitIndex])
                    {
                        OnEmergencyStopTriggerOff[t](t);
                        onEmergencyStopTriggerOff(t);
                    }
                }
                for (int t = 0; t < SenserNum; t++)
                {
                    int bitIndex = (int)ConveyorInputDevice.Senser1 + t;
                    if (Input[bitIndex] != LastInput[bitIndex] && Input[bitIndex])
                    {
                        OnSenserTriggerOn[t](t);
                        onSenserTriggerOn(t);
                    }
                    else if (Input[bitIndex] != LastInput[bitIndex] && !Input[bitIndex])
                    {
                        OnSenserTriggerOff[t](t);
                        onSenserTriggerOff(t);
                    }
                }
                for (int t = 0; t < BitNum; t++)
                {
                    if (Input[t])
                        OnInputOn[t](t, Input[t]);
                    else
                        OnInputOff[t](t, Input[t]);
                    if (Output[t])
                        OnOutputOn[t](t, Output[t]);
                    else
                        OnOutputOff[t](t, Output[t]);
                }
                onEveryWorkingUnit(Config.workingUnit);
                for (int t = 0; t < WaitingAction.Count; t++)
                {
                    DelayAction action = WaitingAction[t];
                    bool conditionTrue = false;
                    switch (action.WaitingDevice)
                    {
                        case DelayActionWaitingDevice.ChangeoverState:
                            conditionTrue = ChStatus[action.DeviceIndex] == (ConveyorChState)action.WaitingValue;
                            break;
                        case DelayActionWaitingDevice.CrossoverState:
                            conditionTrue = CrStatus[action.DeviceIndex] == (ConveyorCrState)action.WaitingValue;
                            break;
                        case DelayActionWaitingDevice.InputBit:
                            conditionTrue = input[action.DeviceIndex] == (bool)action.WaitingValue;
                            break;
                        case DelayActionWaitingDevice.MainRollerState:
                            conditionTrue = mrState == (ConveyorMRState)action.WaitingValue;
                            break;
                        case DelayActionWaitingDevice.OutputBit:
                            conditionTrue = output[action.DeviceIndex] == (bool)action.WaitingValue;
                            break;
                        case DelayActionWaitingDevice.StopperState:
                            conditionTrue = StStatus[action.DeviceIndex] == (ConveyorStState)action.WaitingValue;
                            break;
                    }
                    if (conditionTrue)
                        action.waitingTime -= Config.workingUnit;
                    if (action.waitingTime <= 0)
                    {
                        action.Thread.Interrupt();
                        WaitingAction.RemoveAt(t--);
                    }
                }
                Array.Copy(Input, LastInput, BitNum);
                Array.Copy(Output, LastOutput, BitNum);
                Thread.Sleep(Config.workingUnit);
            }
        }

        public static void cleanDelegate()
        {
            for (int t = 0; t < EmergencyStopNum; t++)
            {
                OnEmergencyStopTriggerOn[t] = NoAction._int;
                OnEmergencyStopTriggerOff[t] = NoAction._int;
            }
            for (int t = 0; t < SenserNum; t++)
            {
                OnSenserTriggerOn[t] = NoAction._int;
                OnSenserTriggerOff[t] = NoAction._int;
            }
            for (int t = 0; t < BitNum; t++)
            {
                OnInputOff[t] = NoAction._int_bool;
                OnInputOn[t] = NoAction._int_bool;
                OnOutputOff[t] = NoAction._int_bool;
                OnOutputOn[t] = NoAction._int_bool;
            }
            onEveryWorkingUnit = NoAction._int;
            onEmergencyStopTriggerOn = NoAction._int;
            onEmergencyStopTriggerOff = NoAction._int;
            onSenserTriggerOn = NoAction._int;
            onSenserTriggerOff = NoAction._int;
        }

        public static void waitForInput(int deviceIndex, bool on, int waitingTime)
        {
            WaitingAction.Add(new DelayAction(DelayActionWaitingDevice.InputBit, deviceIndex, on, waitingTime, Thread.CurrentThread));
            wait();
        }

        public static void waitForOutput(int deviceIndex, bool on, int waitingTime)
        {
            WaitingAction.Add(new DelayAction(DelayActionWaitingDevice.OutputBit, deviceIndex, on, waitingTime, Thread.CurrentThread));
            wait();
        }

        public static void waitForChangeover(int deviceIndex, ConveyorChState state, int waitingTime)
        {
            WaitingAction.Add(new DelayAction(DelayActionWaitingDevice.ChangeoverState, deviceIndex, state, waitingTime, Thread.CurrentThread));
            wait();
        }

        public static void waitForCrossover(int deviceIndex, ConveyorCrState state, int waitingTime)
        {
            WaitingAction.Add(new DelayAction(DelayActionWaitingDevice.CrossoverState, deviceIndex, state, waitingTime, Thread.CurrentThread));
            wait();
        }

        public static void waitForMainRoller(ConveyorMRState state, int waitingTime)
        {
            WaitingAction.Add(new DelayAction(DelayActionWaitingDevice.MainRollerState, 0, state, waitingTime, Thread.CurrentThread));
            wait();
        }

        public static void waitForStopper(int deviceIndex, ConveyorStState state, int waitingTime)
        {
            WaitingAction.Add(new DelayAction(DelayActionWaitingDevice.StopperState, deviceIndex, state, waitingTime, Thread.CurrentThread));
            wait();
        }

        static void wait()
        {
            try
            {
                Thread.Sleep(Timeout.Infinite);
            }
            catch (ThreadInterruptedException) { }
        }

    }

}
