using ChocolateFactoryApi.Models;
using ChocolateFactoryApi.repositories.interfaces;

namespace ChocolateFactoryApi.services
{
    public class CommonService
    {
        private readonly IRawMaterialRepository _rawMaterialRepository;

        public CommonService(IRawMaterialRepository rawMaterialRepository)
        {
            _rawMaterialRepository = rawMaterialRepository;

        }

        public async Task<bool> checkRawMaterialExists(List<RawMaterial> ingredients)
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                RawMaterial rawMaterial = await _rawMaterialRepository.getRawMaterialByNameAsync(ingredients[i].Name);
                if(rawMaterial.StockQuantity - ingredients[i].StockQuantity < 0)
                    return false;
            }
            return true;
        }
    }
}
