namespace Application.Interface.Repository
{
    public interface ICommandsRepository <T>
    {
        void create(T command);
        void update(Guid id,T command);
        void delete(Guid id);
    }
}
