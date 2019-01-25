namespace SVAuto.BL.Handlers.Interfaces
{
    public interface IUpdateHandler<TEntity>
    {
        HandlerResult Execute(TEntity entity);
    }
}
