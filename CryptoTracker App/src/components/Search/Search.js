import React, { useState, useEffect } from "react";
import axios from "../../api/axios";
import './Search.css';

function Search() {
    const [cryptoList, setCryptoList] = useState(''); 
    const [cryptoResults, setCryptoResults] = useState([]);

    useEffect(() => {
        getCryptoList();
    }, [])

    const liveSearch = val => {
        console.log(results);
        var results = cryptoList.filter(x => x.includes(val));
    }

    const getCryptoList = () => {
        axios.get('crypto/list').then(res => {
            setCryptoList([res.data])
        })
    }
 
    return (
        <div class="input-group input-group-lg">
            <input type="text" class="form-control" aria-label="Large" aria-describedby="inputGroup-sizing-sm" placeholder="Start Searching for Cryptocurrencies"
                onChange={e => liveSearch(e.target.value)} 
            />
        </div>
    )
}

export default Search;