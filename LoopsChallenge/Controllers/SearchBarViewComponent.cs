using Microsoft.AspNetCore.Mvc;

namespace LoopsChallenge.Controllers;

public class SearchBarViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}
