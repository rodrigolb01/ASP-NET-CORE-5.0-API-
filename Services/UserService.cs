using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Communication;
using WebApplication3.Domain.Models;
using WebApplication3.Domain.Repositories;
using WebApplication3.Domain.Services;



namespace WebApplication3.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<User> FirstOrDefaultAsync(String login, String password)
        {
            return await _userRepository.FirstOrDefaultAsync(login, password);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }
        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                //Do some logging stuff
                return new UserResponse($"An error occured when saving the user: {ex.Message}");
            }
        }
        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            var existingUser = await _userRepository.FindByIdAsync(id); //retorna solicitacao incorreta, se nao existe

            if (existingUser == null)
                return new UserResponse("User not found.");

            existingUser.Name = user.Name;

            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occurend when updating the user: {ex.Message}");
            }
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);

            if (existingUser == null)
                return new UserResponse("User not found.");

            try
            {
                _userRepository.Remove(existingUser);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(existingUser);

            }
            catch (Exception ex)
            {
                //Do some logging stuff
                return new UserResponse($"An error occured when deleting the product: {ex.Message}");
            }
        }
    }
}
