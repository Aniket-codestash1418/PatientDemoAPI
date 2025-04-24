# Patient Data API

This is an ASP.NET Core Web API for managing patient data.  
It allows adding,and retrieving patient information.

## Features

- Add new patients
- Retrieve a list of patients

## API Endpoints

- `POST /api/PatientDetails/addPatientDetails`
- `GET /api/PatientDetails/patientEncounters`


#Hospital Data API
This is an ASP.NET Core Web API for managing Hospital data.  
It allows adding,and retrieving Hospital information and searching hospitl by name ,state and city.

## Features

- Add new Hospitals
- Retrieve a list of Hospitals
- Search hospitals based on name,state and city

  ## API Endpoints

- `POST /api/Hospital/addHospitalDetails`
- `GET /api/Hospital/getHospitalData`
- - `GET /api/Hospital/searchHospitals`
 
#Encounters API
This is an ASP.NET Core Web API for logging Patient Encounters.  

## Features

- Add all the encounters of patients

  ## API Endpoints

- `POST /api/Encounter/logPatientEncounters`

#Practitioner API
This is an ASP.NET Core Web API for searching practitioner details.  

## Features

- Search Practitioner Details with speciality and location

  ## API Endpoints

- `GET /api/Practitioner/searchPractitioner`

## Getting Started

1. Clone the repo
2. Open in Visual Studio
3. Run the project (F5 or Ctrl+F5)

---

Made with ❤️ using ASP.NET Core
