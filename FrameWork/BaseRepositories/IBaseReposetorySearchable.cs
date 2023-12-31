﻿namespace FrameWork.BaseRepositories
{
    public interface IBaseReposetorySearchable<TModel , Tkey , TSearchModel , TSearchResualt> : IBaseRepository<TModel,Tkey>
    {
        List<TSearchModel> Search(TSearchModel s, out int RecordCount);
    }
}
