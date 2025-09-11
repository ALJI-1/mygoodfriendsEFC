using Models;
using Models.DTO;

namespace Services;

public interface IFriendsService
{
    public Task<ResponsePageDto<IFriend>> ReadFriendsAsync(bool seeded, bool flat, string filter, int pageNumber, int pageSize);

    public Task<IFriend> ReadFriendAsync(Guid id, bool flat);

    public Task<IFriend> DeleteFriendAsync(Guid id, bool flat);

}


