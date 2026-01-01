using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteYonetim.Business.Abstract;

namespace SiteYonetim.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BlockController : Controller
    {
        private readonly IBlockService _blockService;
        public BlockController(IBlockService blockService)
        {
            _blockService = blockService;
        }
        public IActionResult Index()
        {
            var values = _blockService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddBlock()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBlock(SiteYonetim.Entity.Concrete.Block block)
        {
            _blockService.TInsert(block);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteBlock(int id)
        {
            var value = _blockService.TGetByID(id);
            _blockService.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateBlock(int id)
        {
            var value = _blockService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateBlock(SiteYonetim.Entity.Concrete.Block block)
        {
            _blockService.TUpdate(block);
            return RedirectToAction("Index");
        }
    }
}