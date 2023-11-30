import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

function AddStudent() {
    const navigate = useNavigate();
    const [formData, setFormData] = useState({
        firstName: '',
        lastName: '',
        email: '',
    });

    const handleInputChange = (event) => {
        const { name, value } = event.target;

        // Validation for firstName and lastName
        if (name === 'firstName' || name === 'lastName') {
            const onlyLettersHyphenSpace = /^[a-zA-Z- ]+$/;
            if (value === '' || onlyLettersHyphenSpace.test(value)) {
                setFormData({ ...formData, [name]: value });
            }
        }
        else {
            setFormData({ ...formData, [name]: value });
        } 
    };

    const handleEmailBlur = (event) => {
        const { name, value } = event.target;

        // Validation for email
        if (name === 'email') {
            const isValidEmail = /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(value);
            if (isValidEmail || value === '') {
                setFormData({ ...formData, [name]: value });
            } else {
                setFormData({ ...formData, [name]: '' });
                alert('invalid email')
            }
        }
    };

    const handleAddStudent = (event) => {
        if (!formData.firstName || !formData.lastName || !formData.email) {
            alert('Please fill in all required fields.');
            return;
        }

        const newStudent = {
            firstName: formData.firstName,
            lastName: formData.lastName,
            email: formData.email,
        };

        // Make a POST request to your API endpoint to add the student
        const apiUrl = "https://localhost:7003" //process.env.REACT_APP_API_BASE_URL;
        fetch(`${apiUrl}/api/students`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(newStudent),
        })
            .then((response) => response.json())
            .then((data) => {
                navigate('/index');
            })
            .catch((error) => {
                console.error('Error adding student:', error);
            });
    };

    return (
        <div className="row justify-content-center" >
            <div className="col-12 col-md-6">
                <h1 className="pb-4">Add New Student</h1>
                <form>
                    <div className="mb-3 row">
                        <label htmlFor="firstName" className="col-sm-3 col-form-label">First Name:</label>
                        <div className="col-sm-9">
                            <input className="form-control"
                                type="text"
                                name="firstName"
                                id="firstName"
                                value={formData.firstName}
                                onChange={handleInputChange}
                                required
                            />
                        </div>
                    </div>
                    <div className="mb-3 row">
                        <label htmlFor="lastName" className="col-sm-3 col-form-label">Last Name:</label>
                        <div className="col-sm-9">
                            <input className="form-control"
                                type="text"
                                name="lastName"
                                id="lastName"
                                value={formData.lastName}
                                onChange={handleInputChange}
                                required
                            />
                        </div>
                    </div>
                    <div className="mb-3 row">
                        <label htmlFor="checkInTime" className="col-sm-3 col-form-label">Email:</label>
                        <div className="col-sm-9">
                            <input className="form-control"
                                type="email"
                                name="email"
                                id="email"
                                value={formData.email}
                                onChange={handleInputChange}
                                onBlur={handleEmailBlur}
                                required
                            />
                        </div>
                    </div>
                    <div className="row pt-3">
                        <div className="col-12">
                            <button type="submit" className="btn btn-primary" onClick={handleAddStudent}>Add Student</button>
                            <button className="btn btn-secondary ms-2" onClick={() => navigate('/index')}>Home</button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default AddStudent;
