// Base URL for reading and fetching patients
const fetchAllUrl = 'https://localhost:7147/api/Hospital/getHospitalData';


// 1. Fetch All Patients
function fetchPatients() {
    fetch(fetchAllUrl)
        .then(res => res.json())
        .then(result => {
            const patients = result.data;
            const tableBody = document.querySelector('#hospitalTable tbody');
            tableBody.innerHTML = '';
            patients.forEach(patient => {
                const row = document.createElement('tr');
                row.innerHTML = `
                    <td>${patient.name}</td>
                    <td>${patient.address}</td>
                    <td>${patient.city}</td>
                    <td>${patient.state}</td>
                    <td>${patient.phoneNumber}</td>
                    <td>${patient.email}</td>
                    <td>${patient.practitionerName}</td>
                    `;
                tableBody.appendChild(row);
            });
        })
        .catch(err => console.error('Error loading patients:', err));
}





// On page load
fetchPatients();
