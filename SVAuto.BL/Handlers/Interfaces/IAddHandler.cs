namespace SVAuto.BL.Handlers.Interfaces
{
    public interface IAddHandler<TEntity>
    {
        HandlerResult Execute(TEntity entity);
    }
}
