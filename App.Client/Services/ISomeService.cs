using App.Client.Models;

namespace App.Client.Services
{
    public interface ISomeService
    {
        SomeModel Get(int id);
        void Update(SomeModel model);
    }
}