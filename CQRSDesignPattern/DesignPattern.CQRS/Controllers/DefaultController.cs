﻿using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.CQRSPattern.Handlers;
using DesignPattern.CQRS.CQRSPattern.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.CQRS.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandlerhandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
        private readonly RemoveProductQueryHandler _removeProductQueryHandler;
        private readonly GetProductUpdateByIdQueryHandler _getProductUpdateByIdQueryHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;

        public DefaultController(GetProductQueryHandler getProductQueryHandlerhandler, CreateProductCommandHandler createProductCommandHandler, GetProductByIdQueryHandler getProductByIdQueryHandler, RemoveProductQueryHandler removeProductQueryHandler, GetProductUpdateByIdQueryHandler getProductUpdateByIdQueryHandler, UpdateProductCommandHandler updateProductCommandHandler)
        {
            _getProductQueryHandlerhandler = getProductQueryHandlerhandler;
            _createProductCommandHandler = createProductCommandHandler;
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
            _removeProductQueryHandler = removeProductQueryHandler;
            _getProductUpdateByIdQueryHandler = getProductUpdateByIdQueryHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getProductQueryHandlerhandler.Handle();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(CreateProductCommand command)
        {
            _createProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }


        public IActionResult GetProduct(int id)
        {
            var values = _getProductByIdQueryHandler.Handle(new GetProductByIDQuery(id));
            return View(values);
        }

        public IActionResult DeleteProduct(int id)
        {
            _removeProductQueryHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var values = _getProductUpdateByIdQueryHandler.Handle(new GetProductUpdateByIDQuery(id));
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductCommand command)
        {
            _updateProductCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

    }
}
