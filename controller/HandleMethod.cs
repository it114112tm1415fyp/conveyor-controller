namespace ConveyorController
{
    public struct HandleMethod
    {

        public int exitPoint;
        public bool upload;

        public HandleMethod(int exitPoint, bool upload)
        {
            this.exitPoint = exitPoint;
            this.upload = upload;
        }

    }
}
