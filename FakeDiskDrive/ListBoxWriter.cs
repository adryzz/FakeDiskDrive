using System.IO;
using System.Text;
using System.Windows.Forms;

public class ListBoxWriter : TextWriter
{
    private ListBox list;
    private StringBuilder content = new StringBuilder();

    public ListBoxWriter(ListBox list)
    {
        this.list = list;
    }

    public override void Write(char value)
    {
        base.Write(value);
        content.Append(value);
        if (value == '\n')
        {
            if (list.InvokeRequired)
            {
                list.Invoke(new AddText((() => list.Items.Add(content.ToString()))));
            }
            else
            {
                list.Items.Add(content.ToString());
            }
        }
        content = new StringBuilder();
    }


    delegate void AddText();
    public override Encoding Encoding
    {
        get { return System.Text.Encoding.UTF8; }
    }
}