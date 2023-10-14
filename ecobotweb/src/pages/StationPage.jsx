import React, { useEffect, useState } from "react";
import axios, * as others from 'axios';

const StationPage = () => {
    const [stations,setStations] = useState([]);
    const axiosGetStations = () =>{
        // const axios = require('axios');
        axios.get('http://localhost:5196/Station/get')
            .then(response =>{
                console.log(response);
                setStations(response.data);
            })
            .catch(error=>{
                console.log(error);
            });
    }

    useEffect(()=>{
        axiosGetStations();
    },[]);

    return(
        <div class="card m-3">
              <div class="card-body">
                <div class="d-flex align-items-center">
                   <h5 class="mb-0">Customer Details</h5>
                    <form class="ms-auto position-relative">
                      <div class="position-absolute top-50 translate-middle-y search-icon px-3"><ion-icon name="search-sharp" role="img" class="md hydrated" aria-label="search sharp"></ion-icon></div>
                      <input class="form-control ps-5" type="text" placeholder="search"/>
                    </form>
                </div>
                <div class="table-responsive mt-3">
                  <table class="table align-middle">
                    <thead class="table-secondary">
                      <tr>
                       <th>Name</th>
                       <th>City</th>
                       <th>Status</th>
                       <th>Longitude</th>
                       <th>Latitude</th>
                      </tr>
                    </thead>
                    <tbody>
                      {stations&&
                        stations.map((item,index)=>(
                            <tr key={index}>
                                <td>{item.name}</td>
                                <td>{item.city}</td>
                                <td>{item.status}</td>
                                <td>{item.latitude}</td>
                                <td>{item.longitude}</td>
                            </tr>
                        ))
                      }
                    </tbody>
                  </table>
                </div>
              </div>
            </div>
    )
}

export default StationPage;