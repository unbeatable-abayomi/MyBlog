using MyBlog.Data;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Repository
{
    public class RepositoryClass : IRepository
    {
        private readonly AppDbContext _cxt;

        public RepositoryClass(AppDbContext cxt)
        {
            _cxt = cxt;
        }
        public void AddPost(Post post)
        {
            _cxt.Posts.Add(post);
        }

        public List<Post> GetAllPost()
        {
            return _cxt.Posts.ToList();
        }
        public List<Post> GetAllPost(string category)
        {
            return _cxt.Posts.Where(post => post.Category.ToLower().Equals(category.ToLower())).ToList();
        }
        public Post GetPost(int id)
        {
            return _cxt.Posts.FirstOrDefault(p => p.Id == id);
        }

        public void RemovePost(int id)
        {
            _cxt.Posts.Remove(GetPost(id));
        }

      

        public void UpdatePost(Post post)
        {
            _cxt.Posts.Update(post);
        }
        public async Task<bool> SaveChangeAsync()
        {
            if(await _cxt.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
