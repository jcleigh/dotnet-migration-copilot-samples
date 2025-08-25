using System;
using System.Collections.Generic;
using ContosoUniversity.Services;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Controllers
{
    public class NotificationsController : BaseController
    {
        // GET: api/notifications - Get pending notifications for admin
        [HttpGet]
        public JsonResult GetNotifications()
        {
            var notifications = new List<Notification>();
            
            try
            {
                // Read all available notifications from the queue
                Notification notification;
                while ((notification = notificationService.ReceiveNotification()) != null)
                {
                    notifications.Add(notification);
                    
                    // Limit to prevent overwhelming the UI
                    if (notifications.Count >= 10)
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error retrieving notifications: {ex.Message}");
                return Json(new { success = false, message = "Error retrieving notifications" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { 
                success = true, 
                notifications = notifications,
                count = notifications.Count 
            }, JsonRequestBehavior.AllowGet);
        }

        // POST: api/notifications/mark-read
        [HttpPost]
        public JsonResult MarkAsRead(int id)
        {
            try
            {
                notificationService.MarkAsRead(id);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error marking notification as read: {ex.Message}");
                return Json(new { success = false, message = "Error updating notification" });
            }
        }

        // GET: Notifications/Index - Admin notification dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}
