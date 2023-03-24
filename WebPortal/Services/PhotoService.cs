using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using WebPortal.Interfaces;
using WebPortal.Models.Helpers;


namespace WebPortal.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudDinary;
        public PhotoService(IOptions<CloudinarySettings> config)
        {

            var acc = new Account(
                config.Value.CloudName= "ddqlylgxm",
                config.Value.ApiKey = "391859122964345",
                config.Value.ApiSecret = "ghuDwtarXh9yX8houeqh6tFISgY"
                );
            _cloudDinary = new Cloudinary(acc);
        }
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if(file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                };
                uploadResult = await _cloudDinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = await _cloudDinary.DestroyAsync(deleteParams);

            return result;
        }
    }
}
