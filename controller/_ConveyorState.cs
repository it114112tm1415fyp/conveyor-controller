
namespace ConveyorController
{

    /// <summary>
    /// Changeover State
    /// </summary>
    enum ConveyorChState
    {
        Down = 0,
        Up = 1,
        Forward = 2,
        Backward = 4
    }

    /// <summary>
    /// Crossover State
    /// </summary>
    enum ConveyorCrState
    {
        Stop,
        Forward,
        Backward
    }

    /// <summary>
    /// Main Roller State
    /// </summary>
    enum ConveyorMRState
    {
        Stop,
        Clockwise,
        Anticlockwise
    }

    /// <summary>
    /// Stopper State
    /// </summary>
    enum ConveyorStState
    {
        Down,
        Up
    }

}
