using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class LibeyUserRepository : ILibeyUserRepository
    {
        private readonly Context _context;
        public LibeyUserRepository(Context context)
        {
            _context = context;
        }
        public void Create(LibeyUser libeyUser)
        {
            var usuarioExistente = FindResponse(libeyUser.DocumentNumber);
            if (usuarioExistente.DocumentNumber != null && usuarioExistente.DocumentNumber.Length > 0)
                _context.LibeyUsers.Update(libeyUser);
            else
                _context.LibeyUsers.Add(libeyUser);

            _context.SaveChanges();
        }


        public LibeyUserResponse FindResponse(string documentNumber)
        {

            var q = from libeyUser in _context.LibeyUsers.Where(x => x.DocumentNumber.Equals(documentNumber) && x.Active == true)
                    select new LibeyUserResponse()
                    {
                        DocumentNumber = libeyUser.DocumentNumber,
                        Active = libeyUser.Active,
                        Address = libeyUser.Address,
                        DocumentTypeId = libeyUser.DocumentTypeId,
                        Email = libeyUser.Email,
                        FathersLastName = libeyUser.FathersLastName,
                        MothersLastName = libeyUser.MothersLastName,
                        Name = libeyUser.Name,
                        Password = libeyUser.Password,
                        Phone = libeyUser.Phone
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new LibeyUserResponse();
        }


        public IList<LibeyUserResponse> FindAll(string documentNumber)
        {

            var q = from libeyUser in _context.LibeyUsers
                .Include(l => l.Ubigeo)
                    .ThenInclude(u => u.Province)
                .Include(l => l.Ubigeo)
                    .ThenInclude(u => u.Region)

                .Where(x => x.DocumentNumber.Contains(documentNumber) || x.Name.Contains(documentNumber))
                .Where(x => x.Active == true)
                    select new LibeyUserResponse()
                    {
                        DocumentNumber = libeyUser.DocumentNumber,
                        Active = libeyUser.Active,
                        Address = libeyUser.Address,
                        DocumentTypeId = libeyUser.DocumentTypeId,
                        Email = libeyUser.Email,
                        FathersLastName = libeyUser.FathersLastName,
                        MothersLastName = libeyUser.MothersLastName,
                        Name = libeyUser.Name,
                        Password = libeyUser.Password,
                        Phone = libeyUser.Phone,

                        UbigeoCode = libeyUser.Ubigeo.UbigeoCode,
                        ProvinceCode = libeyUser.Ubigeo.Province.ProvinceCode,
                        RegionCode = libeyUser.Ubigeo.Region.RegionCode,

                        UbigeoDescription = libeyUser.Ubigeo.UbigeoDescription,
                        ProvinceDescription = libeyUser.Ubigeo.Province.ProvinceDescription,
                        RegionDescription = libeyUser.Ubigeo.Region.RegionDescription
                    };
            var list = q.ToList();
            if (list.Any()) return list;
            else return new List<LibeyUserResponse>();
        }

        public void Delete(string documentNumber)
        {
            var userToDelete = _context.LibeyUsers.FirstOrDefault(u => u.DocumentNumber == documentNumber);
            if (userToDelete != null)
            {
                userToDelete.Active = false;
                _context.LibeyUsers.Update(userToDelete);
                _context.SaveChanges();
            }
        }

    }
}