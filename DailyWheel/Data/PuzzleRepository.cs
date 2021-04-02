using DailyWheel.Model;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyWheel.Data
{
    interface IPuzzleRepository
    {
        Task<PuzzleModel?> GetAsync(string day);
        Task SaveAsync(PuzzleModel puzzleModel);
    }

    public class PuzzleRepository : IPuzzleRepository
    {
        private readonly Container container;

        public PuzzleRepository(CosmosClient cosmosClient)
        {
            container = cosmosClient.GetContainer("DailyWheel", "Puzzles");
        }

        public async Task<PuzzleModel?> GetAsync(string day)
        {
            using var queryIterator = container.GetItemLinqQueryable<PuzzleModel?>()
                .Where(p => p != null && p.Day == day)
                .ToFeedIterator();

            var results = new List<PuzzleModel?>();
            while (queryIterator.HasMoreResults)
                foreach (var i in await queryIterator.ReadNextAsync())
                    results.Add(i);

            return results.SingleOrDefault();

        }

        public async Task SaveAsync(PuzzleModel puzzleModel)
        {
            puzzleModel.Id = Guid.NewGuid();
            await container.CreateItemAsync(puzzleModel, new PartitionKey(puzzleModel.Day));
        }
    }
}
