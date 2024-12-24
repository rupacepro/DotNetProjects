namespace DependencyInjection.Services
{
    public interface IVehicleService
    {
        Guid id { get; }
        int GetWheelCount();
    }
}
