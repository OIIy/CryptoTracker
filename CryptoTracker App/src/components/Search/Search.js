import React, { useState, useEffect } from "react";
import axios from "../../api/axios";
import CryptoTable from "../CryptoTable/CryptoTable";
import Dropdown from "./Dropdown";
import './Search.css';

function Search() {
    const [cryptoList, setCryptoList] = useState([]); 
    const [cryptoData, setCryptoData] = useState([]);
    const [searchString, setSearchString] = useState('');
    const [searchDisabled, setSearchDisabled] = useState(true);

    useEffect(() => {
        getCryptoData();
    }, [])

    useEffect(() => {
        if (cryptoData.length) {
            setSearchDisabled(false);
        }
    }, [cryptoData])

    useEffect(() => {
        renderResultsDropdown();
    }, [cryptoData])

    const renderResultsDropdown = () => {
        return <Dropdown data={cryptoData}/>
    }

    const getCryptoData = async () => {
        await axios.get('crypto/list').then(response => {
            setCryptoData(response.data);
        });
    }
 
    const liveSearch = val => {
        val = val.toUpperCase();

        var results = cryptoData.filter(x => x.CodeDescription.toUpperCase().includes(val));
        
        var displayResults = results.slice(0, 15);
        
        console.log(results);
        setSearchString(val);
        setCryptoList(displayResults);
    }

    return (
        <div class="input-group input-group-lg">
            <input type="text" class="form-control" aria-label="Large" aria-describedby="inputGroup-sizing-sm" placeholder="Start Searching for Cryptocurrencies"
                onChange={e => liveSearch(e.target.value)}
                disabled={searchDisabled}
            />
            {searchString.length >= 3 && <Dropdown data={cryptoList}></Dropdown>}
        </div>
    )
}

export default Search;