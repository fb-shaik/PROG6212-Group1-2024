using Donut_Shop_Library; //import to the reference of the Class Library created

namespace MyDonut_Shop
{
    public partial class Donut_Shop : Form
    {
        public Donut_Shop()
        {
            InitializeComponent();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            //create 2 int variables to hold the input from the textboxes
            //make sure to convert the above
            int qtyDonuts = Convert.ToInt32(txtbDonuts.Text);
            int qtyCoffee = Convert.ToInt32(txtbCoffee.Text);

            //create an instance of the order class 
            //used to pass along the qty Donut & qty Coffee from the textboxes
            Order o = new Order(qtyDonuts,qtyCoffee);

            //add a message box to display the total order based on qty passed along
            MessageBox.Show(o.CalculateTotal().ToString());
        }
    }
}
