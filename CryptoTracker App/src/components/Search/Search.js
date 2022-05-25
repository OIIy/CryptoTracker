import React, { useState, useEffect } from "react";
import axios from "../../api/axios";
import Dropdown from "./Dropdown";
import './Search.css';

function Search() {
    const [cryptoList, setCryptoList] = useState([]); 
    const [cryptoResults, setCryptoResults] = useState([]);
    const [searchString, setSearchString] = useState('');

    useEffect(() => {
        getCryptoList();
    }, [])

    useEffect(() => {
        renderResultsDropdown();
    }, [cryptoResults])

    const renderResultsDropdown = () => {
        return <Dropdown data={cryptoResults}/>
    }

    const getCryptoList = async () => {
        const response = await axios.get('crypto/list');
        return await setCryptoList(response.data);
    }
 
    const liveSearch = val => {
        var results = cryptoList.filter(x => x.CodeDescription.includes(val))
        setSearchString(val);
        setCryptoResults(results);
    }

    return (
        <div class="input-group input-group-lg">
            <input type="text" class="form-control" aria-label="Large" aria-describedby="inputGroup-sizing-sm" placeholder="Start Searching for Cryptocurrencies"
                onChange={e => liveSearch(e.target.value)} 
            />
            {searchString.length >= 3 && <Dropdown data={cryptoResults}></Dropdown>}
        </div>
    )
}

export default Search;