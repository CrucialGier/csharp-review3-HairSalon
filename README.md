# Hair Salon
### By Stewart Cole, 7/15/2016 ###
<br>

### Setup

* Assuming you are running on windows and you have mono and nancy installed. (http://www.mono-project.com/docs/getting-started/install/windows/)
* Clone the repository at
(https://github.com/CrucialGier/csharp_review2_word-finder.git)
* using the command git clone
* Create empty databases using the .sql files provided by opening them in Microsoft SQL Server Manager Studio and executing the scripts or type the commands :

CREATE DATABASE hair_salon |
GO |
USE hair_salon |
GO |
CREATE TABLE clients |
( |
	id int IDENTITY(1,1), |
	name varchar(255), |
  stylistId int |
) |
GO |
CREATE TABLE dbo.stylists |
( |
	id int IDENTITY(1,1), |
	name varchar(255) |
) |
GO |

* Enter the files directory using the console and enter dnu restore and then dnx kestrel

* Visit localhost:5004 in your web browser.


### Specs

* When the user enters a new Stylist or Client, that value should by saved to the database for use later.
   * Input: "Rebecca";
   * Output: Database Row: Id - 1, Name - Rebecca;


* When the user visits the Stylists or Clients page it should retrieve and display all applicable instances.
  * Input: User Clicks "View Stylists";
  * Output: Page Displayes: "Rebecca", "George", "Sam";


* It can delete all instances of Stylists or Clients.
  * Input: User Clicks "Delete All Clients";
  * Output: Database is Emptied, Page displayes: "You have no clients"


* It can find a specific client or stylist based on their id numbers.
  * Input: User clicks a stylist;
  * Output: Webpage finds and displayes all clients with matching ids;


* It can edit the name of a client or stylist.
  * Input: User Clicks "Edit Client" and enters "George";
  * Output: Page Returns updated client "George";


* It can delete specific clients or stylists.
  * Input: User Clicks "Delete Client" button;
  * Output: Webpage Removes that client from the list of clients;


* It can find all clients for a specific stylist.
  * Input: User Clicks "Rebecca";
  * Output: Webpage returns Rebecca's page with a list of her clients.

### Known Bugs

None at the moment

### Technologies Used

Atom
C#
Html
Nancy
Razor
SQL
Microsoft SQL Server Management Studio

### Copyright

Stewart Cole copyright(c) 7/15/2016
