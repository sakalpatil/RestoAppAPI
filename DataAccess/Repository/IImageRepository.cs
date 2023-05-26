using RestoAppAPI.Modal;

namespace RestoAppAPI.Repository
{
    public interface IImageRepository
    {
        string Save(ImageModal image);
    }
}