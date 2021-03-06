﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Models;

namespace TRMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Cashier")] // Cashier,Admin -> for multi role
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ProductController (IConfiguration config)
        {
            this._config=config;
        }

        [HttpGet]
        public List<ProductModel> Get ()
        {
            ProductData data = new ProductData(_config);

            return data.GetProducts();
        }
    }
}