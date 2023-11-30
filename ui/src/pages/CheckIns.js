import React, { useState, useEffect } from 'react';
import { Link, useParams, useNavigate } from 'react-router-dom';
import formatDatetime from '../utils/dateUtils';

const CheckIns = () => {
    const [checkIns, setCheckIns] = useState([]);
    const [loading, setLoading] = useState(true);
    const { studentid } = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        const populateCheckInData = async (studentid) => {
            try {
                const apiUrl = "https://localhost:7003" //process.env.REACT_APP_API_BASE_URL;
                const response = await fetch(`${apiUrl}/api/students/${studentid}/checkin`);
                const data = await response.json();
                setCheckIns(data);
                setLoading(false);
            } catch (error) {
                console.error('Error fetching check-ins:', error);
            }
        };

        populateCheckInData(studentid);
    }, [studentid]);

    const renderCheckInTable = (checkIns) => (
        <table className='table table-striped my-4' aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th scope="col">Student Email</th>
                    <th scope="col">Major</th>
                    <th scope="col">Check In Time</th>
                </tr>
            </thead>
            <tbody>
                {checkIns.map(checkin => 
                    <tr key={checkin.id}>
                        <td>{checkin.email}</td>
                        <td>{checkin.major}</td>
                        <td>{formatDatetime(checkin.checkInTime)}</td>
                    </tr>
                )}
            </tbody>
        </table>
    );

    const contents = loading ? <p>Loading...</p> : renderCheckInTable(checkIns);

    return (
        <div className="row">
            <div className="col-12">
                <h1 id="tabelLabel">Check Ins</h1>
                {contents}
                <Link to="/add-checkin" className="btn btn-primary" >Add Check In</Link>
                <button className="btn btn-secondary ms-2" onClick={() => navigate('/index')}>Home</button>
            </div>
        </div>
    );
};

export default CheckIns;
