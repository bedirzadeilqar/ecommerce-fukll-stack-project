using ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ecommerce.Controllers
{
    public class SiteController : Controller
    {
        DataDataContext db = new DataDataContext();
        // GET: Site
        public ActionResult Index()
        {
            ViewBag.Menyu = db.Menyus.ToList();
            ViewBag.Xidmet = db.Xidmets.ToList();
            ViewBag.Team = db.Teams.ToList();
            ViewBag.About1 = db.About1s.ToList();
            ViewBag.SlideIndex = db.Slides.ToList();
            return View();
        }
        public ActionResult Indexza()
        {
            return View();
        }
        public ActionResult About1()
        {
            return View();
        }
        public ActionResult Team()
        {
            return View();
        }
        public ActionResult Menyu()
        {
            return View();
        }
        public ActionResult menyu()
        {
            return View();
        }


        public ActionResult insertcontact(Contact newcontact)
        {
            db.Contacts.InsertOnSubmit(newcontact);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }



        public ActionResult Detail(int id)
        {
            var det = db.Menyus.SingleOrDefault(x => x.MenyuId == id);

            return View(det);
        }

        //public ActionResult Login()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult Login(string login, string pass)
        {
            var pasword = CreateMD5("bedir" + pass + "bedir");
            DataTable dt = Sql.Exec($"select UserId,UserName from Users where UserName = N'{login}' and UserPassword = N'{pasword}'");
            if (dt.Rows.Count != 0)
            {
                var deneme = dt.Rows[0][1].ToString();
                HttpCookie cookie = new HttpCookie("User");
                cookie.Values.Add("UserId", dt.Rows[0][0].ToString());
                cookie.Values.Add("UserName", dt.Rows[0][1].ToString());
                cookie.Expires.AddDays(30d);
                Response.Cookies.Add(cookie);
                return RedirectToAction("Profilim");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SignUp(string username, string password, string password2, string UserEmail)
        {
            DataTable dt = Sql.Exec($"Select * from Users where UserName=N'{username}' or UserEmail=N'{UserEmail}'");
            var paswordmain = CreateMD5("bedir" + password + "bedir");
            if (dt.Rows.Count == 0)
            {
                Sql.Exec($"Insert into Users (UserName,UserPassword,UserEmail) values(N'{username}',N'{paswordmain}',N'{UserEmail}')");
                return RedirectToAction("Profilim");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Profilim()
        {

            try
            {
                var cookie = Request.Cookies["User"];
                if (cookie != null)
                {
                    List<Gender> gender = new List<Gender>();
                    ViewBag.gender = db.Genders.ToList();
                    var z2 = Convert.ToInt32(cookie["UserId"]);
                    List<User> user = new List<User>();
                    //ViewBag.user = db.Users.ToList();
                    List<Basket> Basket = new List<Basket>();
                    ViewBag.Basket = db.Baskets.Where(x => x.BasketUserId == z2);

                    var user2 = db.Users.SingleOrDefault(x => x.UserId == z2);
                    return View(user2);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            catch (Exception)
            {
                return View();
            }

        }



        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public ActionResult ForgetPass()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ForgetPass1(string UserName, string UserEmail, string randomkod, string newpass)
        {
            DataTable dt = Sql.Exec($"Select * from Users where UserEmail=N'{UserEmail}'");
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0][1].ToString() == UserName && dt.Rows[0][3].ToString() == UserEmail)
                {
                    Random a = new Random();
                    var kod = a.Next(100000, 999999);
                    MailMessage mesajim = new MailMessage();
                    SmtpClient istemci = new SmtpClient();
                    istemci.Credentials = new System.Net.NetworkCredential("ilqarbedir@hotmail.com", "bedir123");
                    istemci.Port = 587;
                    istemci.Host = "smtp.live.com";
                    istemci.EnableSsl = true;
                    mesajim.To.Add(UserEmail);
                    mesajim.From = new MailAddress("ilqarbedir@hotmail.com");
                    mesajim.Subject = "The Code for RePassword";
                    mesajim.Body = kod.ToString();
                    istemci.Send(mesajim);
                    Sql.Exec($"Update Users set UserRandomCode=N'{kod}',UserRandomCodeDate = GETDATE() where UserName=N'{UserName}' and UserEmail=N'{UserEmail}'");
                    return RedirectToAction("NewPass");
                }
                else
                {
                    return RedirectToAction("ForgetPass");
                }
            }
            else
            {
                return RedirectToAction("ForgetPass");
            }

        }

        public ActionResult NewPass()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewPass1(string UserEmail, string UserRandomCode, string UserPassword)
        {
            DataTable dt = Sql.Exec($"Select * from Users where UserEmail=N'{UserEmail}'");
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0][4].ToString() == UserRandomCode)
                {
                    var paswordmain = CreateMD5("bedir" + UserPassword + "bedir");
                    Sql.Exec($"update Users set UserPassword=N'{paswordmain}' where UserEmail=N'{UserEmail}'");
                    return RedirectToAction("Profilim");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }

        }


        public ActionResult UserPasswordEdit(int id, User newuser, string UserPassword, string NewUserPassword)
        {
            User olduser = db.Users.SingleOrDefault(x => x.UserId == id);
            var Password = CreateMD5("bedir" + UserPassword + "bedir");
            var NewPassword = CreateMD5("bedir" + NewUserPassword + "bedir");

            if (olduser.UserPassword == Password)
            {
                olduser.UserPassword = NewPassword;
                db.SubmitChanges();
                return RedirectToAction("Logout");
            }
            return RedirectToAction("Profilim");
        }

        public ActionResult Logout()
        {
            HttpCookie cookie = new HttpCookie("User");
            cookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");

        }

        public ActionResult Changeinformation(int id, string UserCinsId, string UserNumber, User newuser, HttpPostedFileBase UserPhoto)
        {
            User olduser = db.Users.SingleOrDefault(x => x.UserId == id);
            if (olduser != null)
            {
                if (UserPhoto != null)
                {
                    string Photoname = "Photo" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + Path.GetExtension(UserPhoto.FileName);
                    UserPhoto.SaveAs(Server.MapPath("~/Content/img/" + Photoname));
                    olduser.UserPhoto = Photoname;
                }
                olduser.UserNumber = newuser.UserNumber;
                olduser.UserCinsId = newuser.UserCinsId;
                db.SubmitChanges();
                return RedirectToAction("Logout");
            }
            else
            {
                return RedirectToAction("Profilim");
            }
        }

        public ActionResult silbasket(int id)
        {
            db.Baskets.DeleteOnSubmit(db.Baskets.SingleOrDefault(x => x.BasketId == id));
            db.SubmitChanges();
            return RedirectToAction("Profilim");
        }



        public ActionResult basket(int id, string BasketNumber)
        {
            var cookie = Request.Cookies["User"];
            var count = Convert.ToInt32(BasketNumber);
            if (cookie != null)
            {
                List<Menyu> newmenyu = new List<Menyu>();
                var za = db.Menyus.SingleOrDefault(x => x.MenyuId == id);
                Basket newbasket = new Basket();
                newbasket.BasketName = za.MenyuName;
                newbasket.BasketPhoto = za.MenyuPhoto;

                newbasket.BasketNumber = count;
                newbasket.BasketPrice = Convert.ToInt32(za.MenyuQiymet);
                newbasket.BasketUserId = Convert.ToInt32(cookie["UserId"]);
                db.Baskets.InsertOnSubmit(newbasket);
                db.SubmitChanges();

                return RedirectToAction("Profilim");

            }
            else
            {
                return RedirectToAction("Profilim");
            }


        }

        public ActionResult sifraiwtamam(int id)
        {
            var z = db.TotalPrices.Where(x => x.BasketUserId == id).Sum(x => x.Price);
            var User = db.Users.SingleOrDefault(x => x.UserId == id);
            var userbalans = User.UserBalans;
            if (userbalans >= z)
            {
                User.UserBalans = User.UserBalans - z;
                db.SubmitChanges();
                return RedirectToAction("Profilim");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult buy(int id,string BasketNumber)
        {
            var cookie = Request.Cookies["User"];
            var count = Convert.ToInt32(BasketNumber);
           
            var i = db.Menyus.SingleOrDefault(x => x.MenyuId == id);
            var price = Convert.ToInt32(i.MenyuQiymet);
            var User = db.Users.SingleOrDefault(x => x.UserId == Convert.ToInt32(cookie["UserId"]));

            int totalprice = price * count;
            var userbalans = User.UserBalans;
            if (userbalans >= totalprice)
            {
                userbalans = userbalans - totalprice;
                User.UserBalans = userbalans;
                db.SubmitChanges();
                return RedirectToAction("Detail", new {id = id });
            }
            else
            {

            }
            return View();
        }



    }


}