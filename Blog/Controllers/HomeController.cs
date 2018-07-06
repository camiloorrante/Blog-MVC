using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using Blog.Entity;
using System.Collections;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        Home home = new Home();
        PostDetails postDetails = new PostDetails();
        BlogDBContext db = new BlogDBContext();
        
        public ActionResult Index()
        {
            home.Posts = db.Posts.ToList<Post>();
            return View(home);
        }

        public ActionResult CreateEdit(int? id)
        {
            Post post = new Post()            
            {
                Title = String.Empty,
                Content = String.Empty,
                Date = DateTime.Now,
                Category = null
            };
            if (id == null)
            {  
                
                home.Categories = db.Categories.ToList();
                home.Post = post;
                return View(home);
            }
            else
            {
                home.Categories = db.Categories.ToList();
              
                post = db.Posts.Find(id);
                if (post == null)
                {
                    return HttpNotFound();
                }
                home.Post = post;
               
                return View(home);
            }
            
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                postDetails.Post = db.Posts.Find(id);
                postDetails.Comments = 
                    db.Comments.Where(
                        s => 
                            s.PostId == postDetails.Post.PostId).ToList<Comment>();
                return View(postDetails);
            }
        }

        // POST: Posts/Delete/5
        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}