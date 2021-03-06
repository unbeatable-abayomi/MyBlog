﻿using MyBlog.Comments;
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
       List <Post> GetAllPost(string category);

        void UpdatePost(Post post);
        void AddPost(Post post);
        void RemovePost(int id);
        void AddSubComments(SubComment comment);


        Task<bool> SaveChangeAsync();
    }
}
