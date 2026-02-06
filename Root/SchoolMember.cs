namespace Dap.Root;

public class SchoolMember
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    private int _Phone;

    public int Phone
    {
        get
        {
            return _Phone;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception("Invalid Phone Number");
            }
            _Phone = value;
        }
    }
}