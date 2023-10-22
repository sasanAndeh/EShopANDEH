namespace FrameWork.BaseRepositories
{
    public interface IBaseReposetorySearchable<TModel , Tkey , TSearchModel , TSearchResualt> : IBaseRepository<TModel,Tkey>
    {
        TSearchResualt Search(TSearchModel s, out int RecordCount);
    }
}
