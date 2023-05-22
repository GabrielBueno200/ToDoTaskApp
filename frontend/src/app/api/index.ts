import axios, { AxiosResponse } from 'axios';

const api = axios.create({ baseURL: 'http://localhost:5245/api' });

const responseBody = <T> (response: AxiosResponse<T>) => response.data;

const typedHttpRequest ={ 
    get: <T> (url: string) => api.get<T>(url).then(responseBody),
    post:  <T> (url: string, body: T) => api.post<T>(url, body).then(responseBody),
    put: <T> (url: string, body: T) => api.put(url, body).then(responseBody),
    delete: (url: string) => api.delete(url).then(responseBody)
}

export default typedHttpRequest;