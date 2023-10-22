namespace FrameWork.DTOS
{
    public class OperationResult
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public int? RecordID { get; private set; }
        public string Operation { get; private set; }
        public DateTime OperationDate { get; private set; }

        public OperationResult(string Operation)
        {
            this.OperationDate = DateTime.Now;
            this.Success = false;
            this.Operation = Operation;
        }
        public OperationResult(string Operation , int RecordID)
        {
            this.OperationDate = DateTime.Now;
            this.Success = false;
            this.Operation = Operation;
            this.RecordID = RecordID;
        }
        public OperationResult ToFail(string Message) {

            this.Success = false;
            this.Message = Message;
            return this;
        }
        public OperationResult ToSuccess(string Message)
        {

            this.Success = true;
            this.Message = Message;
            return this;
        }
        public OperationResult ToSuccess(string Message, int RecordID)
        {

            this.Success = true;
            this.Message = Message;
            this.RecordID = RecordID;
            return this;
        }
    }
}
