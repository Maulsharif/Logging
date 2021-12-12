using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.LoggingService;
using BrainstormSessions.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BrainstormSessions.Controllers
{
    public class SessionController : Controller
    {
        private readonly IBrainstormSessionRepository _sessionRepository;

        public SessionController(IBrainstormSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<IActionResult> Index(int? id)
        { 
            Logger.Debug("SessionController Index page call");
            if (!id.HasValue)
            {
                Logger.Error($"{id} is null");
                return RedirectToAction(actionName: nameof(Index),
                    controllerName: "Home");
            }

            var session = await _sessionRepository.GetByIdAsync(id.Value);
            if (session == null)
            {
                Logger.Error($"Session wasn't found for id: {id.Value}");
                return Content("Session not found.");
            }

            var viewModel = new StormSessionViewModel()
            {
                DateCreated = session.DateCreated,
                Name = session.Name,
                Id = session.Id
            };
            Logger.Debug($"SessionController Index return session by Id: {viewModel.Id}");
            return View(viewModel);
        }
    }
}
