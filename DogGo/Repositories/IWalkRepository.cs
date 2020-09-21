using DogGo.Models;
using System.Collections.Generic;

namespace DogGo.Repositories
{
    public interface IWalksRepository
    {
        List<Walk> GetWalksByWalkerId(int walkerId);
        void AddWalks(Walk walks);
    }
}