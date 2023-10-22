using FrameWork.DTOS;

namespace FrameWork.BaseRepositories
{
    public interface IBaseRepository<TModel, TKey>
    {
        TModel GetbyId(TKey id);
        OperationResult Remove(TKey id);
        OperationResult Update(TModel curent);
        List<TModel> GetAll();
        OperationResult Regester(TModel curent);

    }
}
