namespace SVAuto.BL.Handlers.Interfaces
{
    public interface IGetHandler<TEntity>
    {
        HandlerResult<TEntity> Execute(int id);
    }
}
