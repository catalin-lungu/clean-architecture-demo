import { format } from 'date-fns';

function formatDatetime(datetimeString) {
    const date = new Date(datetimeString);
    return format(date, 'MMMM d, yyyy h:mm a');
}

export default formatDatetime;