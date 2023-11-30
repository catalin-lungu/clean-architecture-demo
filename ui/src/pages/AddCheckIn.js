import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

function AddCheckIn() {
    const navigate = useNavigate();

    let majorsFile = { "majors": [{ "name": "Accounting" }, { "name": "Business Analytics" }, { "name": "Business Information Systems" }, { "name": "Business Research" }, { "name": "Finance" }, { "name": "General Management" }, { "name": "Hospitality Business" }, { "name": "Human Resource Management" }, { "name": "Logistics" }, { "name": "Marketing" }, { "name": "Marketing Research" }, { "name": "Operations and Sourcing Management" }, { "name": "Strategic Management" }, { "name": "Supply Chain Management" }, { "name": "Computer Engineering" }, { "name": "Computer Science" }, { "name": "Software Engineering" }, { "name": "Animal Science" }, { "name": "Biosystems Engineering" }, { "name": "Community Sustainability" }, { "name": "Conservation Law" }, { "name": "Environmental Design (MA)" }, { "name": "Environmental Economics and Policy" }, { "name": "Food Industry Management" }, { "name": "Food Science" }, { "name": "Forestry" }, { "name": "Human Nutrition" }, { "name": "Interior Design" }, { "name": "Landscape Architecture" }, { "name": "Nutritional Sciences" }, { "name": "Composition" }, { "name": "Jazz Studies" }, { "name": "Music" }, { "name": "Music Composition" }, { "name": "Music Education" }, { "name": "Music Performance" }, { "name": "Music Theory" }, { "name": "Applied Spanish Linguistics" }, { "name": "Arabic" }, { "name": "Art Education" }, { "name": "Art History" }, { "name": "Chinese" }, { "name": "English" }, { "name": "Film Studies" }, { "name": "French" }, { "name": "German" }, { "name": "Hispanic Literatures" }, { "name": "Interdisciplinary Humanities" }, { "name": "Japanese" }, { "name": "Linguistics" }, { "name": "Literature in English" }, { "name": "Philosophy" }, { "name": "Professional Writing" }, { "name": "Religious Studies" }, { "name": "Russian" }, { "name": "Spanish (BA)" }, { "name": "Studio Art (BA)" }, { "name": "Theatre (MFA)" }, { "name": "Womens and Gender Studies" }, { "name": "Advertising" }, { "name": "Communication" }, { "name": "Journalism" }, { "name": "Media and Information (BA)" }, { "name": "Public Relations" }, { "name": "Curriculum, Instruction and Teacher Education" }, { "name": "Education" }, { "name": "Science Education" }, { "name": "Student Affairs Administration" }, { "name": "Teaching and Curriculum" }, { "name": "Urban Education" }, { "name": "Chemical Engineering" }, { "name": "Civil Engineering" }, { "name": "Computer Engineering" }, { "name": "Computer Science" }, { "name": "Electrical Engineering" }, { "name": "Engineering Mechanics" }, { "name": "Environmental Engineering" }, { "name": "Materials Science and Engineering" }, { "name": "Mechanical Engineering" }, { "name": "Biochemistry and Molecular Biology" }, { "name": "Biostatistics" }, { "name": "Epidemiology" }, { "name": "Microbiology" }, { "name": "Physiology" }, { "name": "Astrophysics" }, { "name": "Cell and Molecular Biology" }, { "name": "Chemistry" }, { "name": "Genetics" }, { "name": "Geological Sciences" }, { "name": "Human Biology" }, { "name": "Mathematics" }, { "name": "Microbiology" }, { "name": "Neuroscience" }, { "name": "Physics" }, { "name": "Physiology" }, { "name": "Predental" }, { "name": "Premedical" }, { "name": "Preoptometry" }, { "name": "Statistics" }, { "name": "Anthropology" }, { "name": "Chicano/Latino Studies" }, { "name": "Child Development (BA)" }, { "name": "Economics" }, { "name": "History" }, { "name": "Political Science" }, { "name": "Psychology" }, { "name": "Public Policy" }, { "name": "Sociology" }, { "name": "Youth and Community Studies" }] }

    const getCurrentDateTime = () => {
        const now = new Date();
        const formattedDateTime = now.toISOString().slice(0, 16);
        return formattedDateTime;
    };

    const [formData, setFormData] = useState({       
        major: majorsFile.majors.length > 0 ? majorsFile.majors[0].name : '',
        email: '',
        checkInTime: getCurrentDateTime(),
    });

    const handleInputChange = (event) => {
        const { name, value } = event.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleAddCheckIn = () => {       

        if (!formData.major || !formData.email || !formData.checkInTime) {
            alert('Please fill in all required fields.');
            return;
        }

        const newCheckIn = {
            major: formData.major,
            email: formData.email,
            checkInTime: formData.checkInTime,
        };

        const apiUrl = "https://localhost:7003" //process.env.REACT_APP_API_BASE_URL;
        fetch(`${apiUrl}/api/checkin`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(newCheckIn),
        })
            .then((response) => response.json())
            .then((data) => {
                navigate('/index');
            })
            .catch((error) => {
                console.error('Error adding checkin:', error);
            });
    };

    return (
        <div className="row justify-content-center" >
            <div className="col-12 col-md-6">
                <h1 className="pb-4">Add New Check In</h1>
                <form>
                    <div className="mb-3 row">
                        <div className="col">
                            <select name="major" value={formData.major} onChange={handleInputChange}
                                placeholder="Select a major"
                                className="form-select">
                                {
                                    majorsFile.majors.map(
                                        (major, index) => (
                                            <option key={index} value={major.name}>{major.name}</option>
                                        ))
                                }
                            </select>
                        </div>
                    </div>                    
                    <div className="mb-3 row">
                        <label  className="col-sm-3 col-form-label">Email:</label>
                        <div className="col-sm-9">
                            <input className="form-control"
                                type="email"
                                name="email"
                                value={formData.email}
                                onChange={handleInputChange}
                            />
                        </div>
                    </div>
                    <div className="mb-3 row">
                        <label className="col-sm-3 col-form-label">Check In Time:</label>
                        <div className="col-sm-9">
                            <input className="form-control"
                                type="datetime-local"
                                name="checkInTime"
                                value={formData.checkInTime}
                                onChange={handleInputChange}
                            />  
                        </div>
                    </div>

                    <div className="row pt-3">
                        <div className="col-12">
                            <button type="button" className="btn btn-primary" onClick={handleAddCheckIn}>Add Check In</button>
                            <button className="btn btn-secondary ms-2" onClick={() => navigate('/index')}>Home</button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default AddCheckIn;
