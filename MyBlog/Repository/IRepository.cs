using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Repository
{
    public interface IRepository
    {
        Post GetPost(int id);
       List <Post> GetAllPost();

        void UpdatePost(Post post);
        void AddPost(Post post);
        void RemovePost(int id);
        Task<bool> SaveChangeAsync();
    }
}
