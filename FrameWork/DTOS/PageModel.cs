namespace FrameWork.DTOS
{
    public class PageModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int RecordCount { get; set; }
        public int PageCount { get; set; }
    }
}
