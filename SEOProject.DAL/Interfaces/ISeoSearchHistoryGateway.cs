using SEOProject.DAL.Entities;

namespace SEOProject.DAL.Interfaces;

public interface ISeoSearchHistoryGateway
{
    void AddSeoSearchHistory(IEnumerable<SeoSearchHistoryEntity> seoSearchHistoryEntities);

    void AddSeoSearchHistory(SeoSearchHistoryEntity seoSearchHistoryEntity);
}
