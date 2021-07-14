using ecommerce.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerce.Controllers
{
    public class AdminController : Controller
    {
        DataDataContext db = new DataDataContext();
        // GET: Admin


        public ActionResult Index()
        {
            ViewBag.SlideIndex = db.Slides.ToList();

            return View();
        }
        public ActionResult Delete(int id)
        {
            db.Slides.DeleteOnSubmit(db.Slides.SingleOrDefault(x => x.SlideId == id));
            db.SubmitChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Edit(int id)
        {
            ViewBag.SlideIndex = db.Slides.ToList();

            return View();
        }

        public ActionResult newslide()
        {
            return View();
        }
        public ActionResult Insertnewslide(Slide newslide, HttpPostedFileBase SlidePhoto)
        {
            if (SlidePhoto != null)
            {
                string Photoname = "Photo" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(SlidePhoto.FileName);
                SlidePhoto.SaveAs(Server.MapPath("~/Content/img/" + Photoname));
                newslide.SlidePhoto = Photoname;
            }

            db.Slides.InsertOnSubmit(newslide);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult editslide(int id)
        {
            var sli = db.Slides.SingleOrDefault(x => x.SlideId == id);
            return View(sli);
        }
        public ActionResult updateslide(int id, Slide newslide, HttpPostedFileBase SlidePhoto)
        {
            Slide oldslide = db.Slides.SingleOrDefault(x => x.SlideId == id);
            if (SlidePhoto != null)
            {
                string Photoname = "Photo" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(SlidePhoto.FileName);
                SlidePhoto.SaveAs(Server.MapPath("~/Content/img/" + Photoname));
                oldslide.SlidePhoto = Photoname;
            }
            oldslide.SlideName = newslide.SlideName;
            db.SubmitChanges();
            return RedirectToAction("Index");
        }





        public ActionResult About1()
        {
            ViewBag.About1 = db.About1s.ToList();
            return View();
        }
        public ActionResult newabout()
        {
            return View();
        }
        public ActionResult insertnewabout(About1 newabout, HttpPostedFileBase AboutPhoto)
        {
            About1 oldabout = new About1();
            if (AboutPhoto != null)
            {
                string Photoname = "Photo" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(AboutPhoto.FileName);
                AboutPhoto.SaveAs(Server.MapPath("~/Content/img/" + Photoname));
                oldabout.AboutPhoto = Photoname;
            }
            oldabout.AboutText = newabout.AboutText;
            db.About1s.InsertOnSubmit(oldabout);
            db.SubmitChanges();
            return RedirectToAction("About1");
        }

        public ActionResult DeleteAbout(int id)
        {
            db.About1s.DeleteOnSubmit(db.About1s.SingleOrDefault(x => x.AboutId == id));
            db.SubmitChanges();
            return RedirectToAction("About1");
        }

        public ActionResult Aboutindex(int id)
        {
            ViewBag.Aboutindex = db.About1s.ToList();

            return View();
        }

        public ActionResult editabout(int id)
        {
            var edi = db.About1s.SingleOrDefault(x => x.AboutId == id);
            return View(edi);
        }
        public ActionResult updateabout(int id, About1 newabout, HttpPostedFileBase AboutPhoto)
        {
            About1 oldaboutphoto = db.About1s.SingleOrDefault(x => x.AboutId == id);
            if (AboutPhoto != null)
            {
                string Photoname = "Photo" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(AboutPhoto.FileName);
                AboutPhoto.SaveAs(Server.MapPath("~/Content/img/" + Photoname));
                oldaboutphoto.AboutPhoto = Photoname;
            }
            oldaboutphoto.AboutText = newabout.AboutText;
            db.SubmitChanges();
            return RedirectToAction("About1");
        }





        public ActionResult newteam()
        {
            return View();
        }
        public ActionResult insertnewteam(Team newteam, HttpPostedFileBase TeamPhoto)
        {
            Team oldteam = new Team();
            if (TeamPhoto != null)
            {
                string Photoname = "Photo" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(TeamPhoto.FileName);
                TeamPhoto.SaveAs(Server.MapPath("~/Content/img/" + Photoname));
                oldteam.TeamPhoto = Photoname;
            }
            oldteam.TeamName = newteam.TeamName;
            oldteam.TeamVezife = newteam.TeamVezife;
            db.Teams.InsertOnSubmit(oldteam);
            db.SubmitChanges();
            return RedirectToAction("Team");
        }

        public ActionResult DeleteTeam(int id)
        {
            db.Teams.DeleteOnSubmit(db.Teams.SingleOrDefault(x => x.TeamId == id));
            db.SubmitChanges();
            return RedirectToAction("Team");
        }

        public ActionResult Team()
        {
            ViewBag.Team = db.Teams.ToList();
            return View();
        }

        public ActionResult editteam(int id)
        {
            var tea = db.Teams.SingleOrDefault(x => x.TeamId == id);
            return View(tea);
        }
        public ActionResult updateteam(int id, Team newteam, HttpPostedFileBase TeamPhoto)
        {
            Team oldteamphoto = db.Teams.SingleOrDefault(x => x.TeamId == id);
            if (TeamPhoto != null)
            {
                string Photoname = "Photo" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(TeamPhoto.FileName);
                TeamPhoto.SaveAs(Server.MapPath("~/Content/img/" + Photoname));
                oldteamphoto.TeamPhoto = Photoname;
            }
            oldteamphoto.TeamName = newteam.TeamName;
            db.SubmitChanges();
            return RedirectToAction("Team");
        }




        public ActionResult xidmet()
        {
            ViewBag.Xidmet = db.Xidmets.ToList();
            return View();
        }
        public ActionResult newxidmet()
        {
            return View();
        }
        public ActionResult insertnewxidmet(Xidmet newxidmet)
        {
            Xidmet oldxidmet = new Xidmet();
            oldxidmet.XidmetName = newxidmet.XidmetName;
            oldxidmet.XidmetText = newxidmet.XidmetText;
            db.Xidmets.InsertOnSubmit(oldxidmet);
            db.SubmitChanges();
            return RedirectToAction("Xidmet");
        }
        public ActionResult Deletexidmet(int id)
        {
            db.Xidmets.DeleteOnSubmit(db.Xidmets.SingleOrDefault(x => x.XidmetId == id));
            db.SubmitChanges();
            return RedirectToAction("Xidmet");
        }
        public ActionResult editXidmet(int id)
        {
            var xid = db.Xidmets.SingleOrDefault(x => x.XidmetId == id);
            return View(xid);
        }
        public ActionResult updatetXidmet(int id, Xidmet newxidmet)
        {
            Xidmet oldxidmet = db.Xidmets.SingleOrDefault(x => x.XidmetId == id);
            oldxidmet.XidmetName = newxidmet.XidmetName;
            oldxidmet.XidmetText = newxidmet.XidmetText;
            db.SubmitChanges();
            return RedirectToAction("xidmet");
        }

        public ActionResult contact()
        {
            ViewBag.Contact = db.Contacts.ToList();
            return View();
        }

        public ActionResult menyu()
        {
            ViewBag.Menyu = db.Menyus.ToList();
            return View(); 
        }
        public ActionResult newmenyu()
        {
            ViewBag.Menyu = db.Categories.ToList();
            return View();
        }
        public ActionResult insertnewmenyu(Menyu newmenyu,HttpPostedFileBase MenyuPhoto)
        {
            Menyu oldmenyu = new Menyu();
            if (MenyuPhoto != null)
            {
                string PhotoName = "Photo" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(MenyuPhoto.FileName);
                MenyuPhoto.SaveAs(Server.MapPath("~/Content/img/" + PhotoName));
                oldmenyu.MenyuPhoto = PhotoName;
            }
            oldmenyu.MenyuName = newmenyu.MenyuName;
            oldmenyu.MenyuText = newmenyu.MenyuText;
            oldmenyu.MenyuQiymet = newmenyu.MenyuQiymet;
            oldmenyu.MenyuCategoryId = newmenyu.MenyuCategoryId;
            db.Menyus.InsertOnSubmit(oldmenyu);
            db.SubmitChanges();
            return RedirectToAction("menyu");
        }

        public ActionResult deletemenyu(int id)
        {  
            db.Menyus.DeleteOnSubmit(db.Menyus.SingleOrDefault(x => x.MenyuId == id));
            db.SubmitChanges();
            return RedirectToAction("Menyu");
        }

        public ActionResult editmenyu(int id)
        {
            ViewBag.Menyu = db.Categories.ToList();
            var men = db.Menyus.SingleOrDefault(x => x.MenyuId == id);
            return View(men);
        }


        public ActionResult updatemenu(int id, Menyu newmenyu, HttpPostedFileBase MenyuPhoto)
        {
            Menyu oldmenyuphoto = db.Menyus.SingleOrDefault(x => x.MenyuId == id);
            if (MenyuPhoto != null)
            {
                string Photoname = "Photo" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(MenyuPhoto.FileName);
                MenyuPhoto.SaveAs(Server.MapPath("~/Content/img/" + Photoname));
                oldmenyuphoto.MenyuPhoto = Photoname;
            }
            oldmenyuphoto.MenyuName = newmenyu.MenyuName;
            oldmenyuphoto.MenyuCategoryId = newmenyu.MenyuCategoryId;
            oldmenyuphoto.MenyuText = newmenyu.MenyuText;
            oldmenyuphoto.MenyuQiymet = newmenyu.MenyuQiymet;
            db.SubmitChanges();
            return RedirectToAction("menyu");
        }

        public ActionResult newcategory()
        {
            return View();
        }
        public ActionResult category()
        {
            ViewBag.Category = db.Categories.ToList();
            return View();
        }
        public ActionResult insertnewcategory(Category newcategory)
        {
            db.Categories.InsertOnSubmit(newcategory);
            db.SubmitChanges();
            return RedirectToAction("category");
        }
        public ActionResult deletecategory(int id)
        {
            db.Categories.DeleteOnSubmit(db.Categories.SingleOrDefault(x => x.CategoryId == id));
            db.SubmitChanges();
            return RedirectToAction("category");
        }

        public ActionResult editcategory(int id)
        {
             var oldcategory = db.Categories.SingleOrDefault(x => x.CategoryId == id);
            return View(oldcategory);
        }
        public ActionResult updatecategory(int id,Category newcategory)
        {
            Category oldcategory = new Category(); 
            oldcategory = db.Categories.SingleOrDefault(x => x.CategoryId == id);
            oldcategory.CategoryName = newcategory.CategoryName;
            db.SubmitChanges();
            return RedirectToAction("category");
        }




        public ActionResult users()
        {
            ViewBag.user = db.Users.ToList();
            return View();
        }

        public ActionResult deleteuser(int id)
        {
            db.Users.DeleteOnSubmit(db.Users.SingleOrDefault(x => x.UserId == id));
            db.SubmitChanges();
            return RedirectToAction("users");
        }

        public ActionResult edituser(int id)
        {
            ViewBag.user = db.Users.ToList();
            var use = db.Users.SingleOrDefault(x => x.UserId == id);
            return View(use);
        }

        public ActionResult updateuser(int id, User newuser, HttpPostedFileBase UserPhoto)
        {
            User olduserphoto = db.Users.SingleOrDefault(x => x.UserId == id);
            if (UserPhoto != null)
            {
                string Photoname = "Photo" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(UserPhoto.FileName);
                UserPhoto.SaveAs(Server.MapPath("~/Content/img/" + Photoname));
                olduserphoto.UserPhoto = Photoname;
            }
            olduserphoto.UserName = newuser.UserName;
            olduserphoto.UserEmail = newuser.UserEmail;
            olduserphoto.UserNumber = newuser.UserNumber;
            olduserphoto.UserBalans = newuser.UserBalans;
            db.SubmitChanges();
            return RedirectToAction("users");

        }

    }
}

