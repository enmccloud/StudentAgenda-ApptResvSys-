﻿using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAgenda.Areas.GroupMember.Models;

namespace StudentAgenda.Areas.GroupMember.Controllers
{
    [Area("GroupMember")]
    public class HomeController : Controller
    {
        private GroupMembersContext context { get; set; }

        public HomeController(GroupMembersContext ctx)
        {
            context = ctx;
        }

        [Authorize]
        public IActionResult Index()
        {
            var groups = context.GroupMembers
                .OrderBy(m => m.Name).ToList();
            return View(groups);
        }
    }
}
