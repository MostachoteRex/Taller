using Application.DTOs.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IService<CreateDTO, UpdateDTO, DTO>
    {
        bool Create(CreateDTO request);
        bool Delete(string id);
        DTO Get(string id);
        List<DTO> GetAll();
        bool Update(string id, UpdateDTO request);
    }
}
