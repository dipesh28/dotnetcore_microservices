using PlatformService.Models;

namespace PlatformService.Data 
{
    public interface IPlatformRepository {
        bool SaveChanges();
        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlaformById(int id);
        void CreatePltform(Platform platform);
    }
}