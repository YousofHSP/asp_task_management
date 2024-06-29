using Entities;

namespace DTO;

public class DesktopDto: BaseDto<DesktopDto, Desktop>
{
    public string Title { get; set; }
    public string OwnerFullName { get; set; }
    public int OwnerUserId { get; set; }
    
}