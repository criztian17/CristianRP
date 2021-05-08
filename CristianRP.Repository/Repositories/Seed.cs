using CristianRP.Repository.Entities;
using CristianRP.Repository.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristianRP.Repository.Repositories
{
    public class Seed
    {
        #region Attibutes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        public Seed(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task SeedAsync()
        {
            await _unitOfWork.DataContext.Database.EnsureCreatedAsync();

            if (!_unitOfWork.DataContext.Users.Any())
            {
                var users = new List<UserEntity>
                {
                    new UserEntity { Login = "cristian@test.com.co", Pwd = Utilities.Utilities.Encrypt("cristian") },
                    new UserEntity { Login = "camilo@test.com.co", Pwd = Utilities.Utilities.Encrypt("camilo") },
                    new UserEntity { Login = "lucas@test.com.co", Pwd = Utilities.Utilities.Encrypt("lucas") },
                };

                await _unitOfWork.DataContext.Users.AddRangeAsync(users);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
