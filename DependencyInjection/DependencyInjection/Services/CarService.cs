
namespace DependencyInjection.Services
{
    public class CarService : IVehicleService, IDisposable
    {
        private Guid _id;

        public CarService()
        {
            _id = Guid.NewGuid();
        }
        public Guid id { get
            {
                return _id;
            } }

        public void Dispose()
        {
            //close the database connection
        }

        public int GetWheelCount()
        {
            return 4;
        }
    }
}
