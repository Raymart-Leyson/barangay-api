
# Cebu City Family Records

## **Project ERD**

![CEBU CITY FAMILY DATABASE ERD](https://user-images.githubusercontent.com/111823676/196019536-70cbced5-67c3-4f48-94b9-ca2c1aff30da.png)

## **Project Summary**
This project delivers capabilities that allow for the efficient management of information regarding Families residing in a certain Barangay. It ensures that a Barangay can maintain track of the Details of each Family Member and the population.

## **Endpoints with Features**
### **Barangay**
#### POST `/api/barangays`
 - Creates a Barangay
#### POST `/api/barangays/{id}/family/register`
 - Registers a Family to a Barangay
#### GET `/api/barangays`
 - Gets all Barangays
#### GET `/api/barangays/search`
 - Gets the Families living in the Barangay by the Barangay Name
#### GET `/api/barangays/{id}/families`
 - Gets the Families living in the Barangay by ID
#### PUT `/api/barangays/{id}`
 - Updates a Barangay
#### DELETE `/api/barangays/{name}`
 - Deletes a Barangay by Name

### **Families**
#### POST `/api/families/{id}/member/register`
 - Register a Family Member to an existing Family
#### GET `/api/families`
 - Gets all Families
#### GET `/api/families/{id}/familymembers`
 - Gets the Family Members with their Details by their Family ID
#### GET `/api/families/search`
 - Gets the Family Members with their Details by their Family Name
#### PUT `/api/families/{id}`
 - Updates where a Family lives
#### DELETE `/api/families/{id}`
 - Deletes a Family by their ID

### **FamilyMembers**
#### POST `/api/familymembers/{id}/details/register`
 - Adds a Family Member's Information
#### GET `/api/familymembers`
 - Gets all Family Members
#### GET `/api/familymembers/{id}/details`
 - Gets a Family Member with their Details by their ID
#### GET `/api/familymembers/search`
 - Gets a Family Member with their Details by their Name
#### PUT `/api/familymembers/{id}`
 - Updates a Family Member
#### Delete `/api/familymembers/{name}`
 - Deletes a Family Member by their Name

### **Details**
#### GET `/api/details`
 - Gets all details
#### PUT `/api/details/{id}`
 - Updates a Family Member`s Details

## **Authors**
Lasaca, Brent S.

Apit, Jhen Sarah C.

Leyson, Raymart N.

Gauson, Delwin Mateo A.

## **Acknowledgements**
Thank you and We Love You Sir Ambrad! ❤️
