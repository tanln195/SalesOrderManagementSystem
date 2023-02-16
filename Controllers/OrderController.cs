using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesOrderManagementSystem.Models;

namespace SalesOrderManagementSystem.Controllers
{
    public class OrderController : Controller
    {
        OrderDataAccessLayer orderDataAccessLayer = null;
        public OrderController()
        {
            orderDataAccessLayer = new OrderDataAccessLayer();
        }
        
        // GET: OrderController
        public ActionResult Index()
        {
            IEnumerable<Order> orders = orderDataAccessLayer.GetAllOrder();
            return View(orders);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(string workOrder)
        {
            Order order = orderDataAccessLayer.GetOrderData(workOrder);
            return View(order);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            try
            {
                // TODO: Add insert logic here
                orderDataAccessLayer.AddOrder(order);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(string workOrder)
        {
            Order order = orderDataAccessLayer.GetOrderData(workOrder);
            return View(order);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            try
            {
                // TODO: Add update logic here
                orderDataAccessLayer.UpdateOrder(order);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(string workOrder)
        {
            Order order = orderDataAccessLayer.GetOrderData(workOrder);
            return View(order);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Order order)
        {
            try
            {
                // TODO: Add delete logic here
                orderDataAccessLayer.DeleteOrder(order.WorkOrder);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
